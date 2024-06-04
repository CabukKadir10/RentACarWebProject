var L = abp.localization.getResource('RentACarProject');

$(function () {
    var _fuelAppService = rentACarProject.fuels.fuel;

    var fuelAddModal = new abp.ModalManager({
        viewUrl: '/Fuel/Add'
    });
    var fuelEditModal = new abp.ModalManager({
        viewUrl: '/Fuel/Update'
    });
    fuelAddModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('AddSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    fuelEditModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('UpdateSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    $('#FuelAddButton').click(async function (event) {
        fuelAddModal.open();
    });
    var _dataTable = $('#FuelTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            ajax: abp.libs.datatables.createAjax(_fuelAppService.getList),
            columnDefs: [
                {
                    title: L('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: L('Edit'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('FuelPermission.Fuel.Update');
                                    },
                                    action: function (data) {
                                        fuelEditModal.open({
                                            id: data.record.id,
                                        });
                                        ///...
                                    }
                                },

                                {
                                    text: L('Delete'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('FuelPermission.Fuel.Delete');
                                    },
                                    confirmMessage: function (data) {
                                        return L(
                                            'FuelDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        toastr.options.positionClass = 'toast-top-right';
                                        _fuelAppService
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