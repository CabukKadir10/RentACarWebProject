var L = abp.localization.getResource('RentACarProject');

$(function () {
    var _brandAppService = rentACarProject.brands.brand;

    var brandAddModal = new abp.ModalManager({
        viewUrl: '/Brand/Add'
    });
    var brandEditModal = new abp.ModalManager({
        viewUrl: '/Brand/Update'
    });
    brandAddModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('AddSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    brandEditModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('UpdateSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    $('#BrandAddButton').click(async function (event) {
        brandAddModal.open();
    });
    var _dataTable = $('#BrandTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            ajax: abp.libs.datatables.createAjax(_brandAppService.getList),
            columnDefs: [
                {
                    title: L('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: L('Edit'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('BrandPermission.Brand.Update');
                                    },
                                    action: function (data) {
                                        brandEditModal.open({
                                            id: data.record.id,
                                        });
                                        ///...
                                    }
                                },

                                {
                                    text: L('Delete'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('BrandPermission.Brand.Delete');
                                    },
                                    confirmMessage: function (data) {
                                        return L(
                                            'BrandDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        toastr.options.positionClass = 'toast-top-right';
                                        _brandAppService
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