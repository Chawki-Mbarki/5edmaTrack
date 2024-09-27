const transferForm = document.querySelector(".transfer-form-box");

document.querySelector(".transfer-form-box .fa-xmark").addEventListener("click", () => {
    toggleVisibility(transferForm);
});

document.querySelector(".transfer-btn").addEventListener("click", () => {
  toggleVisibility(transferForm);
});
