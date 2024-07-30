document.addEventListener('DOMContentLoaded', function () {
    const stars = document.querySelectorAll('.star-rating .star');
    stars.forEach(star => {
        star.addEventListener('click', setRating);
    });

    function setRating(ev) {
        const span = ev.currentTarget;
        const stars = document.querySelectorAll('.star-rating .star');
        let match = false;
        let rating = 0;
        stars.forEach((star, index) => {
            if (match) {
                star.innerHTML = '&#9734;';
            } else {
                star.innerHTML = '&#9733;';
            }
            if (star === span) {
                match = true;
                rating = index + 1;
            }
        });
        document.getElementById('Rating').value = rating;
    }
});