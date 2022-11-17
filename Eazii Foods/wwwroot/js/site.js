// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function addFood() {
	debugger;
	var data = {};
	var image = document.getElementById("image").files
	data.Name = $('#name').val(); 
    data.Price = $('#price').val(); 
    if (image[0] != null) {
        const reader = new FileReader();
        reader.readAsDataURL(image[0]);
        var base64;
        reader.onload = function () {
            base64 = reader.result;
            debugger;
            if (base64 != "" || base64 != 0) {
                let foodViewModel = JSON.stringify(data);
                $.ajax({
                    type: 'Post',
                    dataType: 'Json',
                    url: '/Foods/AddFood',
                    data: {
                        foodDetails: foodViewModel,
                        base64: base64
                    },
                    success: function (result) {
                        debugger;
                        if (!result.isError) {
                            var url = '/Foods/Index'
                            successAlertWithRedirect(result.msg, url)
                        }
                        else {
                            errorAlert(result.msg)
                        }
                    },
                    error: function (ex) {
                        errorAlert("Error occured try again");
                    }

                })

            }
            else {
                errorAlert("Please Enter Details");
            }
        }
    }
}






