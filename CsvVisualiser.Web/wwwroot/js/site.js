// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#apiForm').on('submit', function (event) {

    event.preventDefault();

    var formData = new FormData();

    var file = $('#fileInput')[0].files[0];
    if (file)
    {
        formData.append('file', file);

        $.ajax({
            url: 'https://localhost:50321/Sales',
            data: formData,
            processData: false,
            contentType: false,
            method: 'POST',
            type: 'POST',
            success: function (response) {
                $('#dataOutput').DataTable({
                    data: response,
                    columns: [
                        { data: 'segment' },
                        { data: 'country' },
                        { data: 'product' },
                        { data: 'discountBand' },
                        { data: 'unitsSold' },
                        { data: 'manufacturingPrice' },
                        { data: 'salePrice' },
                        { data: 'date' },
                    ]
                });
            }
        });

        
    }
});