function submitReviewForm() {
    var form = $('#reviewForm');
    console.log('Form:', form);
    var url = '/Review/AddReview';
    console.log('URL:', url);

    $.ajax({
        type: 'POST',
        url: url,
        data: form.serialize(),
        success: function (response) {
            console.log('Response:', response);
            if (response.success) {
                $('#reviewFormResult').html('<div class="alert alert-success">' + response.message + '</div>');
                form[0].reset();
                console.log('Form reset');

                var newReviewHtml = `
                <div class="card review-card mb-3">
                    <div class="card-body">
                        <div class="d-flex align-items-center mb-2">
                            <img src="${response.review.customerProfilePictureUrl}" alt="Customer Image" class="rounded-circle" width="30" height="30">
                            <h5 class="card-title ml-3 mb-0">${response.review.customerFullName}</h5>
                        </div>
                        <p class="card-text">${response.review.content}</p>
                    </div>
                </div>`;
                console.log('New Review HTML:', newReviewHtml);

                var newReviewContainer = $('#new-review');
                if (newReviewContainer.length) {
                    newReviewContainer.append(newReviewHtml);
                    console.log('New review appended');
                } else {
                    console.error('#new-review container not found');
                }

                setTimeout(function () {
                    $('#reviewFormResult').html('');
                    console.log('Review form result cleared');
                }, 1000);
            } else {
                console.log('Response errors:', response.errors);
                if (response.errors) {
                    var errorsHtml = '<div class="alert alert-danger"><ul>';
                    response.errors.forEach(function (error) {
                        errorsHtml += '<li>' + error + '</li>';
                    });
                    errorsHtml += '</ul></div>';
                    $('#reviewFormResult').html(errorsHtml);
                } else {
                    $('#reviewFormResult').html('<div class="alert alert-danger">' + response.message + '</div>');
                }
                setTimeout(function () {
                    $('#reviewFormResult').html('');
                    console.log('Review form result cleared (error)');
                }, 1000);
            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            console.log('AJAX error:', textStatus, errorThrown);
            $('#reviewFormResult').html('<div class="alert alert-danger">An error occurred while submitting your review. Please try again later.</div>');
            setTimeout(function () {
                $('#reviewFormResult').html('');
                console.log('Review form result cleared (AJAX error)');
            }, 1000);
        }
    });
}

$(document).ready(function() {
    $('#reviewForm button[type="button"]').on('click', submitReviewForm);
});
