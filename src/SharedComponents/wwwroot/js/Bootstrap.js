window.hideModal = (identifier) => {
    $(identifier).modal('hide');
};

window.showModal = (identifier) => {
    $(identifier).modal('show');
};

window.toast = (identifier) => {
    $(identifier).toast('show');
};