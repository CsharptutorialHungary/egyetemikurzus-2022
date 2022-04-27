function deleteTodo(i) 
{
    $.ajax({
        url: 'Home/Delete',
        type: 'POST',
        data: {
            id: i
        },
        success: function() {
            window.location.reload();
        }
    });
}

function populateForm(i) {

    $.ajax({
        url: 'Home/PopulateForm',
        type: 'GET', // POST eseten nem mukodne a frissites
        data: {
            id: i
        },
        dataType: 'json',
        success: function (response) {
            $("#Todo_Name").val(response.name);
            $("#Todo_Id").val(response.id);
            $("#form-button").val("Teendő frissítése");
            $("#form-action").attr("action", "/Home/Update");
        }
    });
}
