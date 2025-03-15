// ✅ Toggle Navigation Menu
const hamburger = document.getElementById('hamburger');
const navMenu = document.getElementById('nav-menu');

hamburger.addEventListener('click', () => {
    navMenu.classList.toggle('hidden');
});

// ✅ Smooth Scrolling
const links = document.querySelectorAll('nav a');

links.forEach(link => {
    link.addEventListener('click', event => {
        event.preventDefault();
        const target = document.querySelector(link.getAttribute('href'));
        if (target) {
            target.scrollIntoView({
                behavior: 'smooth'
            });
        }
    });
});

// ✅ Filter Projects
function filterProjects(category) {
    const projects = document.querySelectorAll('.project');

    projects.forEach(project => {
        if (category === 'all' || project.getAttribute('data-category') === category) {
            project.style.display = 'block';
        } else {
            project.style.display = 'none';
        }
    });
}

// ✅ Lightbox for Images
const lightbox = document.getElementById('lightbox');
const lightboxImg = document.getElementById('lightbox-img');

document.querySelectorAll('.lightbox-image').forEach(img => {
    img.addEventListener('click', () => {
        lightboxImg.src = img.src;
        lightbox.classList.remove('hidden');
    });
});

lightbox.addEventListener('click', () => {
    lightbox.classList.add('hidden');
});

// ✅ Form Validation
const form = document.getElementById('contact-form');
const feedback = document.getElementById('form-feedback');

form.addEventListener('submit', (event) => {
    event.preventDefault();

    const name = document.getElementById('name').value.trim();
    const email = document.getElementById('email').value.trim();
    const message = document.getElementById('message').value.trim();

    if (!name || !email || !message) {
        feedback.textContent = 'Please fill in all fields.';
        return;
    }

    if (!validateEmail(email)) {
        feedback.textContent = 'Please enter a valid email address.';
        return;
    }

    feedback.textContent = 'Message sent successfully!';
    feedback.style.color = 'green';

    // Clear form after submission
    form.reset();
});

function validateEmail(email) {
    const re = /\S+@\S+\.\S+/;
    return re.test(email);
}
