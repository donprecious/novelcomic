$(function () { 
    $("#addEpisodeForm").submit(function (event) {
        event.preventDefault();
        var data = $(this).serialize();
       var $form = $(this);
        $.ajax({
            url: $(this).attr("action"),
            type: 'POST',
            data: data,
            dataType: 'json',
            beforeSend: function () {
                $form.find("button[type=submit]").attr('disabled', 'disabled');
                $form.find(".formLoading").show();
            },
            complete: function () {
                $form.find("button[type=submit]").removeAttr('disabled');
                $form.find(".formLoading").hide();

            },
            success: function (response) {
                if (response.status == 200) {
                    //Swal.fire({
                    //    title: 'Success',
                    //    text: 'Created Successfully',
                    //    type: 'success',
                    //    confirmButtonText: 'Done!'
                    //});
                    toastr.success('Created Successfully');

                    $("#sections").load("/Comic/SceneList/" + response.data.comicId); 
                    $("#display").load("/Comic/DisplayEpisode/" + response.data.id);
                    $("#createChapterModal").modal('hide');
                } else if (response.status == 400) {
                    var html = "<ul> ";
                    response.errors.forEach(a => {
                        html += `<li> ${a.errorMessage} </li>`;

                    });
                    $form.find(".alert-warning").html(html + '</ul>');
                    $form.find('.alert-warning').removeClass('hide');
                }
                console.log(response);
            },
            error: function (err) {
                console.log(err);
            }

        });
    });
    $("#addSceneForm").submit(function (event) {
        event.preventDefault();
        var data = $(this).serialize();
        var $form = $(this);
        $.ajax({
            url: $(this).attr("action"),
            type: 'POST',
            data: data,
            dataType: 'json',
            beforeSend: function () {
                $form.find("button[type=submit]").attr('disabled', 'disabled');
                $form.find(".formLoading").show();
            },
            complete: function () {
                $form.find("button[type=submit]").removeAttr('disabled');
                $form.find(".formLoading").hide();

            },
            success: function (response) {
                if (response.status == 200) {
                    Swal.fire({
                        title: 'Success',
                        text: 'Created Successfully',
                        type: 'success',
                        confirmButtonText: 'Done!'
                    });
                    //$("#sections").load("/Comic/SceneList/" + response.data.comicId); 
                    $("##createSectionModal").modal("hide");
                    location.reload();

                } else if (response.status == 400) {
                    var html = "<ul> ";
                    response.errors.forEach(a => {
                        html += `<li> ${a.errorMessage} </li>`;

                    });
                    $form.find(".alert-warning").html(html + '</ul>');
                    $form.find('.alert-warning').removeClass('hide');
                }
                console.log(response);
            },
            error: function (err) {
                console.log(err);
            }

        });
    });
   
});