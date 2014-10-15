$(function () {
    var $modals = $(".modal");
    if ($modals.length) {
        $modals.draggable({
            handle: ".modal-header"
        });
    }
});