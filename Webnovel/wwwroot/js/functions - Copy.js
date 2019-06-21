function activateEditor() {
    var container = $('.editor').get(0);
    var toolbarOptions = [
        ['bold', 'italic', 'underline', 'strike'],        // toggled buttons
        ['blockquote', 'code-block'],

        [{ 'header': 1 }, { 'header': 2 }],               // custom button values
        //[{ 'list': 'ordered'}, { 'list': 'bullet' }],
        /* [{ 'script': 'sub'}, { 'script': 'super' }],*/      // superscript/subscript
        [{ 'indent': '-1' }, { 'indent': '+1' }],          // outdent/indent
        [{ 'direction': 'rtl' }],                         // text direction

        [{ 'size': ['small', false, 'large', 'huge'] }],  // custom dropdown
        [{ 'header': [1, 2, 3, 4, 5, 6, false] }],

        [{ 'color': [] }, { 'background': [] }],          // dropdown with defaults from theme
        [{ 'font': [] }],
        [{ 'align': [] }]

        /*   ['clean']        */                                 // remove formatting button
    ];

    var quill = new Quill('.editor', {
        modules: {
            toolbar: toolbarOptions,
            history: {
                delay: 2000,
                maxStack: 500,
                userOnly: true
            }
        },
        theme: 'snow'
    });
}

function showCreateSection() {
    $("#createSectionModal").modal();
}

function showAddChapter() {
    $("#createChapterModal").modal();
}

function showDisplayChapter(id) {
    $("#displayChapter").empty();
    var url = "/Novel/DisplayChapterView/" + id;
    $.ajax(url,
        {
            type: "GET",
            dataType: "Html",
            beforeSend: function () {

            },
            complete: function () {

            },
            success: function (response) {
                $("#displayChapter").html(response);
            },
            error: function (err) {
                console.log(err);
            }
        });
}
function showEditChapter(id) {
    $("#displayChapter").empty();
    var url = "/Novel/EditChapterView/" + id;
    $.ajax(url,
        {
            type: "GET",
            dataType: "Html",
            beforeSend: function () {

            },
            complete: function () {

            },
            success: function (response) {
                $("#displayChapter").html(response);
                activateEditor();
            },
            error: function (err) {
                console.log(err);
            }
        });

}