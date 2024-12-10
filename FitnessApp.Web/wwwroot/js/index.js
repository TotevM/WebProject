document.addEventListener("DOMContentLoaded", () => {
    const heading = document.querySelector("#about-us h2");

    setTimeout(() => {
        heading.classList.add("done");
    }, 1600); // Matches the animation duration (2 seconds)
});

function manageTeamButtons() {
    const buttons = document.querySelectorAll(".btn[data-bs-toggle='collapse']");

    buttons.forEach(button => {
        const targetID = button.getAttribute("data-bs-target");
        const targetElement = document.querySelector(targetID);

        const toggleBtnTextHandler = (e) => {
            e.preventDefault();

            if (button.textContent === "Learn More") {
                button.textContent = "Hide Away";
                button.classList.add("btn-hide-away");
            } else {
                button.textContent = "Learn More";
                button.classList.remove("btn-hide-away");
                button.style.color = "";
                button.style.borderColor = "";
                button.style.backgroundColor = "";
            }

            let buttonPosition = button.offsetTop;

            window.scrollTo({
                top: buttonPosition + 750,
                behavior: 'smooth'
            });

            if (targetElement.classList.contains('show')) {
                $(targetElement).collapse('hide');
            } else {
                $(targetElement).collapse('show');
            }
        };

        button.addEventListener("click", toggleBtnTextHandler);

        targetElement.addEventListener("shown.bs.collapse", () => {
            button.textContent = "Hide Away";
            button.classList.add("btn-hide-away");
        });

        targetElement.addEventListener("hidden.bs.collapse", () => {
            button.textContent = "Learn More";
            button.classList.remove("btn-hide-away");
        });
    });
}
function scrollToAboutUs() {
    const aboutUsLink = document.querySelector(".btn-outline-secondary");
    const aboutUsSection = document.querySelector("#about-us");

    const scrollToAboutUsHandler = (e) => {
        e.preventDefault();

        aboutUsSection.scrollIntoView({
            behavior: "smooth",
            block: "start"
        });
    };

    if (aboutUsLink && aboutUsSection) {
        aboutUsLink.addEventListener("click", scrollToAboutUsHandler);
    }
}

scrollToAboutUs();
manageTeamButtons();