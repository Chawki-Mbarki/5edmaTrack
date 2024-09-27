const loginForm = document.querySelector(".login-form-box");
const registerForm = document.querySelector(".register-form-box");


document.querySelector(".login-form-box .fa-xmark").addEventListener("click", () => {
    toggleVisibility(loginForm);
  });
  
  document.querySelector(".login-btn").addEventListener("click", () => {
    toggleVisibility(loginForm);
  });
  
  document.querySelector(".log-in-link").addEventListener("click", () => {
    toggleVisibility(loginForm);
  });
  
  document.querySelector(".register-form-box .fa-xmark").addEventListener("click", () => {
    toggleVisibility(registerForm);
  });
  
  document.querySelectorAll(".sign-up-link").forEach((element) => {
    element.addEventListener("click", () => {
      toggleVisibility(registerForm);
    });
  });