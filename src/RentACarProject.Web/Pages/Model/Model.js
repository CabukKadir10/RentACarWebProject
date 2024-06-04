var L = abp.localization.getResource('RentACarProject');

$(function () {
    var _modelAppService = rentACarProject.models.model;

    var modelAddModal = new abp.ModalManager({
        viewUrl: '/Model/Add'
    });
    var modelEditModal = new abp.ModalManager({
        viewUrl: '/Model/Update'
    });
    modelAddModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('AddSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    modelEditModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('UpdateSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    $('#ModelAddButton').click(async function (event) {
        modelAddModal.open();
    });
    var _dataTable = $('#ModelTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            ajax: abp.libs.datatables.createAjax(_modelAppService.getList),
            columnDefs: [
                {
                    title: L('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: L('Edit'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('ModelPermission.Model.Update');
                                    },
                                    action: function (data) {
                                        modelEditModal.open({
                                            id: data.record.id,
                                        });
                                        ///...
                                    }
                                },

                                {
                                    text: L('Delete'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('ModelPermission.Model.Delete');
                                    },
                                    confirmMessage: function (data) {
                                        return L(
                                            'ModelDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        toastr.options.positionClass = 'toast-top-right';
                                        _modelAppService
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
                },
                {
                    title: L('DailyPrice'),
                    data: "dailyPrice"
                },
                {
                    title: L('ImageUrl'),
                    data: "imageUrl"
                },
                {
                    title: L('BrandId'),
                    data: "brandId"
                },
                {
                    title: L('FuelId'),
                    data: "fuelId"
                },
                {
                    title: L('TransmissionId'),
                    data: "transmissionId"
                }
            ]
        })
    );
});