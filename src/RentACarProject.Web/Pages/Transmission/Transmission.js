var L = abp.localization.getResource('RentACarProject');

$(function () {
    var _transmissionAppService = rentACarProject.transmissions.transmission;

    var transmissionAddModal = new abp.ModalManager({
        viewUrl: '/Transmission/Add'
    });
    var transmissionEditModal = new abp.ModalManager({
        viewUrl: '/Transmission/Update'
    });
    transmissionAddModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('AddSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    transmissionEditModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('UpdateSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    $('#TransmissionAddButton').click(async function (event) {
        transmissionAddModal.open();
    });
    var _dataTable = $('#TransmissionTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            ajax: abp.libs.datatables.createAjax(_transmissionAppService.getList),
            columnDefs: [
                {
                    title: L('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: L('Edit'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('TransmissionPermission.Transmission.Update');
                                    },
                                    action: function (data) {
                                        transmissionEditModal.open({
                                            id: data.record.id,
                                        });
                                        ///...
                                    }
                                },

                                {
                                    text: L('Delete'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('TransmissionPermission.Transmission.Delete');
                                    },
                                    confirmMessage: function (data) {
                                        return L(
                                            'TransmissionDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        toastr.options.positionClass = 'toast-top-right';
                                        _transmissionAppService
                                            .delete(data.record.id)
                                            .then(function () {
                                                _dataTable.ajax.reload();
                                                abp.notify.success(L('DeleteSuccess'));
                                            });
                                    },
                                }
                            ]
                    }
                },

                {
                    title: L('Name'),
                    data: "name"
                }

            ]
        })
    );
});