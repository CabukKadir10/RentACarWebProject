var L = abp.localization.getResource('RentACarProject');

$(function () {
    var _carAppService = rentACarProject.cars.car;

    var carAddModal = new abp.ModalManager({
        viewUrl: '/Cars/Add'
    });
    var carEditModal = new abp.ModalManager({
        viewUrl: '/Cars/Update'
    });
    carAddModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('AddSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    carEditModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('UpdateSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    $('#CarAddButton').click(async function (event) {
        carAddModal.open();
    });
    var _dataTable = $('#CarTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            ajax: abp.libs.datatables.createAjax(_carAppService.getList),
            columnDefs: [
                {
                    title: L('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: L('Edit'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('CarsPermissions.Car.Update');
                                    },
                                    action: function (data) {
                                        carEditModal.open({
                                            id: data.record.id,
                                        });
                                        ///...
                                    }
                                },

                                {
                                    text: L('Delete'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('CarsPermissions.Car.Delete');
                                    },
                                    confirmMessage: function (data) {
                                        return L(
                                            'CarDeletionConfirmationMessage',
                                            data.record.plate
                                        );
                                    },
                                    action: function (data) {
                                        toastr.options.positionClass = 'toast-top-right';
                                        _carAppService
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
                    title: L('Plate'),
                    data: "plate"
                },
                {
                    title: L('modelYear'),
                    data: "modelYear"
                },
                {
                    title: L('ModelId'),
                    data: "modelId"
                },
                {
                    title: L('CarState'),
                    data: "carState"
                },
                {
                    title: L('ColorId'),
                    data: "colorId"
                }

            ]
        })
    );
});