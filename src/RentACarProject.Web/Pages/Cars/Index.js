$(function () {
    var l = abp.localization.getResource('BookStore');

    var dataTable = $('#CarsTable').DataTable(
        abp.libs.datatables.normalizeConfiguration({
            serverSide: true,
            paging: true,
            order: [[1, "asc"]],
            searching: false,
            scrollX: true,
            ajax: abp.libs.datatables.createAjax(rentacar.cars.car.getList),
            columnDefs: [
                {
                    title: l('Plate'),
                    data: "plate"
                },
                {
                    title: l('Color'),
                    data: "color",
                    //render: function (data) {
                    //    return l('Enum:BookType.' + data);
                    //}
                },
                {
                    title: l('State'),
                    data: "state",
                    //render: function (data) {
                    //    return luxon
                    //        .DateTime
                    //        .fromISO(data, {
                    //            locale: abp.localization.currentCulture.name
                    //        }).toLocaleString();
                    //}
                },
                {
                    title: l('BrandId'),
                    data: "brandId"
                },
                {
                    title: l('ModelId'), data: "modelId",
                    //render: function (data) {
                    //    return luxon
                    //        .DateTime
                    //        .fromISO(data, {
                    //            locale: abp.localization.currentCulture.name
                    //        }).toLocaleString(luxon.DateTime.DATETIME_SHORT);
                   // }
                }
            ]
        })
    );
});
