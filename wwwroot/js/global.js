const veil = document.querySelector(".veil");

veil.addEventListener("click", () => {
  document.querySelectorAll(".visible").forEach((visibleElement) => {
    if (!visibleElement.classList.contains("hide")) {
      toggleVisibility(visibleElement);
    }
  });
});

function toggleVisibility(target) {
  const isHidden = target.classList.contains("hide");

  document.querySelectorAll(".visible").forEach((ele) => {
    ele.classList.remove("visible");
    ele.classList.add("hide");
  });

  target.classList.toggle("hide", !isHidden);
  target.classList.toggle("visible", isHidden);
  veil.classList.toggle("hide", !isHidden);

  console.log("Is it hidden?:", !isHidden);
}
