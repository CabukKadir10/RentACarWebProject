var L = abp.localization.getResource('RentACarProject');

$(function () {
    var _rentalAppService = rentACarProject.rentals.rental;

    var rentalAddModal = new abp.ModalManager({
        viewUrl: '/Rental/Add'
    });
    var rentalEditModal = new abp.ModalManager({
        viewUrl: '/Rental/Update'
    });
    rentalAddModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('AddSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    rentalEditModal.onResult(function (result, response) {
        if (response.statusText == "success") {
            toastr.options.positionClass = 'toast-top-right';
            abp.notify.success(L('UpdateSucces'));
        }
        // if (response.responseText.showDialogProp.resultStatus==0) {
        _dataTable.ajax.reload();
        //}
    });
    $('#RentalAddButton').click(async function (event) {
        rentalAddModal.open();
    });
    var _dataTable = $('#RentalTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: true,
            ajax: abp.libs.datatables.createAjax(_rentalAppService.getList),
            columnDefs: [
                {
                    title: L('Actions'),
                    rowAction: {
                        items:
                            [
                                {
                                    text: L('Edit'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('RentalPermission.Rental.Update');
                                    },
                                    action: function (data) {
                                        rentalEditModal.open({
                                            id: data.record.id,
                                        });
                                        ///...
                                    }
                                },

                                {
                                    text: L('Delete'),
                                    visible: function (data) {
                                        return abp.auth.isGranted('RentalPermission.Rental.Delete');
                                    },
                                    confirmMessage: function (data) {
                                        return L(
                                            'ModelDeletionConfirmationMessage',
                                            data.record.name
                                        );
                                    },
                                    action: function (data) {
                                        toastr.options.positionClass = 'toast-top-right';
                                        _rentalAppService
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
                    title: L('CarId'),
                    data: "carId"
                },
                {
                    title: L('RentDate'),
                    data: "rentDate"
                },
                {
                    title: L('ReturnDate'),
                    data: "returnDate"
                },
                {
                    title: L('TotalPrice'),
                    data: "totalPrice"
                }
            ]
        })
    );
});