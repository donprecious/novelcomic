$(function () {
    $("#addChapterForm").submit(function (event) {
        event.preventDefault();
        var data = $(this).serialize();

        $.ajax({
            url: $(this).attr("action"),
            type: 'POST',
            data: data,
            dataType: 'json',
            beforeSend: function () {
                $("#btnCreateChapter").attr('disable', 'disable');
                $("#addChapterLoading").show();
            },
            complete: function () {
                $("#btnCreateSection").removeAttr('disable');
                $("#addChapterLoading").hide();

            },
            success: function (response) {
                if (response.status == 200) {
                    Swal.fire({
                        title: 'Success',
                        text: 'Section Created Successfully',
                        type: 'success',
                        confirmButtonText: 'Cool'
                    });
                    $("#sections").load('/Novel/AddSectionView/' + response.data.novelId);
                } else if (response.status == 400) {
                    var html = "<ul> ";
                    response.errors.forEach(a => {
                        html += `<li> ${a.errorMessage} </li>`;

                    });
                    $("#alertNovelError").html(html + '</ul>');
                    $('#alertNovelError').removeClass('hide');

                }
                console.log(response);
            },
            error: function (err) {
                console.log(err);
            }

        });
    });
});