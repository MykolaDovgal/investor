let userPostTags = [];

$(document).ready(function () {

    $("#logoff").click(function(e) {
        e.preventDefault();
        logOff();
	});

	$("#imgInp").change(function () {
		readURL(this);
	});

    $("#createUserPostForm").submit(function(e) {
		e.preventDefault();
		PostAJAX(getCreatePostFormData(this), $(this).attr('action'));
    });

	$("#registerUserForm").submit(function (e) {
		e.preventDefault();
		createRegisterAJAX(getRegistrationFormData(this));
	});

	$("#updateUserDataForm").submit(function (e) {
		e.preventDefault();
		PostAJAX(getUpdateUserDataForm(this), $(this).attr('action'));
	});

	$("#updateUserPasswordForm").submit(function (e) {
		e.preventDefault();
		PostAJAX(getUpdateUserPasswordForm(this), $(this).attr('action'));
	});

	$("#updateUserBiographyForm").submit(function (e) {
		e.preventDefault();
		PostAJAX(getUserBiographyFormData(this), $(this).attr('action'));
	});

    initUserTinyMCE();
    getAllTags();

});

let readURL = function (input) {

	if (input.files && input.files[0]) {
		var reader = new FileReader();

		reader.onload = function (e) {
			$('#imgPrev').attr('src', e.target.result);
		}

		reader.readAsDataURL(input.files[0]);
	}
}


let getCreatePostFormData = function() {
    const formData = new FormData(document.getElementById("createUserPostForm"));

    let tagsArray = $("#userPostTags").tagsinput('items');
	formData.set('Article', tinyMCE.get('createUserPost').getContent());    
    for (let i = 0; i < tagsArray.length; i++)
        formData.append(`Tags[` + i + `].Name`, tagsArray[i]);
    return formData;
}

let getRegistrationFormData = function () {
	const formData = new FormData(document.getElementById("registerUserForm"));
	formData.append("Photo", $(`#upload`).get(0).files === null ? null : $(`#upload`).get(0).files[0]);
	formData.append("Password", $("input[name='pass_confirmation']").val());
	var points = $('#upload-demo').croppie('get').points;
	for (let i = 0; i < points.length; i++)
		formData.append(`CropPoints[` + i + `]`, points[i]);
	formData.append('Socials[0]', $('#input-value-fb').val());
	formData.append('Socials[1]', $('#input-value-tw').val());
	formData.append('Socials[2]', $('#input-value-google').val());
	return formData;
}

let getUserBiographyFormData = function () {
	const formData = new FormData(document.getElementById("updateUserBiographyForm"));
	formData.append("Image", $(`#upload`).get(0).files === null ? null : $(`#upload`).get(0).files[0]);
	formData.append("Photo", $('#userPhoto').attr('src'));
	var points = $('#upload-demo').croppie('get').points;
	for (let i = 0; i < points.length; i++)
		formData.append(`Points[` + i + `]`, points[i]);
	formData.append('Socials[0]', $('#input-value-fb').val());
	formData.append('Socials[1]', $('#input-value-tw').val());
	formData.append('Socials[2]', $('#input-value-google').val());
	return formData;
}

let getUpdateUserDataForm = function () {
	const formData = new FormData(document.getElementById("updateUserDataForm"));
	return formData;
}

let getUpdateUserPasswordForm = function () {
	const formData = new FormData(document.getElementById("updateUserPasswordForm"));
	formData.append("Password", $("input[name='pass_old']").val());
	formData.append("NewPassword", $("input[name='pass_confirmation']").val())
	return formData;
}

let getAllTags = function () {
    $.ajax({
        url: "/api/TagsApi/GetAllTags",
        type: "GET",
        success: function (data) {
            data.data.map(item => {
                userPostTags.push(item.name);
            });
            initUserTagsInput();
        }
    });
}

let substringMatcher = function (strs) {
    return function(q, cb) {
        let matches = [];
        let substringRegex = new RegExp(q, 'i');
        $.each(strs, function (i, str) {
            if (substringRegex.test(str)) {
                matches.push(str);
            }
        });
        cb(matches);
    };
};

let initUserTinyMCE = function () {

    tinymce.init({
        selector: "textarea#createUserPost",
        theme: "modern",
        width: 680,
        height: 300,
        plugins: [
            "advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker",
            "searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
            "save table contextmenu directionality emoticons template paste textcolor"
        ],
        content_css: "css/content.css",
        toolbar: "insertfile undo redo | styleselect | bold italic | alignleft aligncenter alignright alignjustify | bullist numlist outdent indent | link image | print preview media fullpage | forecolor backcolor emoticons",
        style_formats: [
            { title: 'Bold text', inline: 'b' },
            { title: 'Red text', inline: 'span', styles: { color: '#ff0000' } },
            { title: 'Red header', block: 'h1', styles: { color: '#ff0000' } },
            { title: 'Example 1', inline: 'span', classes: 'example1' },
            { title: 'Example 2', inline: 'span', classes: 'example2' },
            { title: 'Table styles' },
            { title: 'Table row 1', selector: 'tr', classes: 'tablerow1' }
        ]
    }); 

}

let initUserTagsInput = function () {
    $("#userPostTags").tagsinput({
        typeaheadjs: {
            name: 'userPostTags',
            source: substringMatcher(userPostTags)
        }
    });
}

let logOff = function() {
    $.ajax({
        url: "/account/logoff",
        type: "POST",
        success: function (data) {
            window.location.href = data;
        }
    });
}

let PostAJAX = function (fData, url) {
    $.ajax({
		url: url,
        type: "POST",
        data: fData,
        cache: false,
        contentType: false,
        processData: false,
        success: function (data) {
            window.location.href = data;
        }
    });
}

let createRegisterAJAX = function (fData) {
	$.ajax({
		url: "/account/register",
		type: "POST",
		data: fData,
		cache: false,
		contentType: false,
		processData: false,
		success: function (data) {
			window.location.href = data;
		}
	});
}