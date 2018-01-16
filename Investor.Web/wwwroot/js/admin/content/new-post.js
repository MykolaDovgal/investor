let initTypeahead = function () {

	var tags = [];
	tinymce.init({
		mode: "specific_textareas",
        selector: ".text-editor",
        language: 'uk_UA',
		content_css: "css/metronic/style.css",
		theme: "modern",
		height: "480",
		plugins: [
			"advlist autolink link image lists charmap print preview hr anchor pagebreak spellchecker",
			"searchreplace wordcount visualblocks visualchars code fullscreen insertdatetime media nonbreaking",
			"save table contextmenu directionality emoticons template paste textcolor"
		],

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

	if (tinymce.editors.length > 0) {
		tinymce.execCommand('mceFocus', true, 'Article');
		tinymce.execCommand('mceRemoveEditor', true, 'Article');
		tinymce.execCommand('mceAddEditor', true, 'Article');
	}

	$(document).ready(function () {

		$.ajax({
			url: "/api/TagsApi/GetAllTags",
			type: "GET",
			success: function (data) {
				data.data.map(item => {
					tags.push(item.name);
				});
			}
		});

		$('#updateFormSubmit').on("click",
			function (e) {
				const $this = $(this);
				$this.attr("disabled", "disabled");
				var formId = $('.updateForm').attr('id');
				var formData = new FormData(document.getElementById(formId));
				const category = formData.get("Category.Url");
				formData.set('IsOnMainPage', $(`#${formId} input[name='IsOnMainPage']`).prop("checked"));
				formData.set('IsPublished', $(`#${formId} input[name='IsPublished']`).prop("checked"));
				formData.set('IsImportant', $(`#${formId} input[name='IsImportant']`).prop("checked"));

				formData.set('IsOnSide', $(`#${formId} input[name='IsOnSide']`).prop("checked"));
				formData.set('IsOnSlider', $(`#${formId} input[name='IsOnSlider']`).prop("checked"));
				formData.set('Article', tinyMCE.get('Article').getContent());
				var tagsArray = $(`#${formId} input[Name='tagsName']`).tagsinput('items');

				for (let i = 0; i < tagsArray.length; i++)
					formData.append(`Tags[` + i + `].Name`, tagsArray[i]);
				var file = $(`#${formId} input[name='Image']`).get(0).files;
				formData.set("Image", $(`#${formId} input[name='Image']`).get(0).files[0]);

				const apiTypeUrl = category ? "NewsApi" : "BlogsApi";
				const apiAction = category ? "UpdateNews" : "UpdateBlog";
				$.ajax({
					type: "POST",
					url: `/api/${apiTypeUrl}/${$(this).data("action")}`,
					data: formData,
					cache: false,
					contentType: false,
					processData: false,
					success: function (data) {
						console.log(data);
						$("#updateFormSubmit").data("action", apiAction);
						$(`#${formId} input[name='PostId']`).val(data["id"]);
						$this.removeAttr("disabled");
						$(`.deletepost`).removeAttr('hidden');
						$(`.previewpost`).removeAttr('hidden');
						$(`.previewpost`).attr('href', data["href"]);

						$.toaster({
							priority: 'success',
							title: 'Операція успішна',
							message: "\nСтаттю збережено!",
							settings: {
								'timeout': 4000
							}
						});
					},
					error: function (data) {
						$this.removeAttr("disabled");
						$.toaster({
							priority: 'error',
							title: 'Упс',
							message: "\nЩось пішло не так!",
							settings: {
								'timeout': 4000
							}
						});
					}


				});
				e.preventDefault();
			});

		$(document).on('submit',
			'.updateForm',
			function (e) {
				//prevent the form from doing a submit
				e.preventDefault();
				return false;
			});
	});

	var substringMatcher = function (strs) {
		return function findMatches(q, cb) {
			var substringRegex;
			var matches = [];
			// regex used to determine if a string contains the substring `q`
			substrRegex = new RegExp(q, 'i');

			// iterate through the pool of strings and for any string that
			// contains the substring `q`, add it to the `matches` array
			$.each(strs, function (i, str) {
				if (substrRegex.test(str)) {
					matches.push(str);
				}
			});
			cb(matches);
		};
	};

	$("#tagTypeahead").tagsinput({
		typeaheadjs: {
			name: 'tags',
			source: substringMatcher(tags)
		}
	});
}








