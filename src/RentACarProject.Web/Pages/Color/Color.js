var L = abp.localization.getResource('RentACarProject');

$(function () {
    var _colorAppService = novaHaber.appServices.colors.color;

    var colorAddModal = new abp.ModalManager({
        viewUrl: '/Color/Add'
    });
    var colorEditModal = new abp.ModalManager({
        viewUrl: '/Color/Update'
    });
    colorAddModal.onResult(function (result, response) {
        if (response.statusText == "success" && response.responseText.showDialogProp == null) {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('AddSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    colorEditModal.onResult(function (result, response) {
        if (response.statusText == "success" && response.responseText.showDialogProp == null) {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('UpdateSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    $('#ColorAddButton').click(async function (event) {
        colorAddModal.open();
    });
    var _dataTable = $('#ColorTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            ajax: abp.libs.datatables.createAjax(_colorAppService.getList),
            columnDefs: [
                {
                    title: L('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: L('Edit'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('ColorPermission.Color.Update');
                                    },
                                    action: function (data) {
                                        colorEditModal.open({
                                            id: data.record.id,
                                        });
                                        ///...
                                    }
                                },

                                {
                                    text: L('Delete'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('ColorPermission.Color.Delete');
                                    },
                                    confirmMessage: function (data) {
                                        return L(
                                            'ColorDeletionConfirmationMessage',
                                            data.record.Name
                                        );
                                    },
                                    action: function (data) {
                                        toastr.options.positionClass = 'toast-top-right';
                                        _colorAppService
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
                    data: "Name"
                }

            ]
        })
    );
});