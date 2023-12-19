function confirmDelete(userId, confirm) {
    var deleteBtn = "DeleteBtn_" + userId;
    var confirmDelete = "ConfirmDelete_" + userId;

    if (confirm) {
        $('#' + deleteBtn).hide();
        $('#' + confirmDelete).show();
    }
    else {
        $('#' + confirmDelete).hide();
        $('#' + deleteBtn).show();
    }
}