let initTypeahead = function () {
	var tags = [];

	$(document).ready(function () {

		tinymce.init({
			mode: "specific_textareas",
			selector: ".text-editor",
			theme: "modern",
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

		$.ajax({
			url: "/api/Content/GetAllTags",
			type: "GET",
			success: function (data) {
				for (let i = 0; i < data.data.length; i++)
					data.data.map(item => {
						tags.push(item.name);
					});

			}
		});

		$("#updateFormSubmit").on('click', function (e) {
			var isvalidate = $("#updateForm")[0].checkValidity();
			if (isvalidate) {
				let formData = new FormData(document.getElementById('updateForm'));
				formData.append("Image", $("input[name='Image']").get(0).files);
				formData.append("Article", $("textarea[name='Article']").text);
				console.log(formData.values);
				e.preventDefault();
				$.ajax({
					type: "POST",
					url: "Admin/Content/UpdatePost",
					data: formData,
					cache: false,
					contentType: false,
					processData: false,
					success: function (data) {
						console.log('lol', data);
					},
					error: function (data) {
						console.log(data);
					}
				});
			}
			else $("#createForm").submit();
		});
		$(document).on('submit', '#updateForm', function (e) {
			//prevent the form from doing a submit
			e.preventDefault();
			return false;
		})

	});
	var substringMatcher = function (strs) {
		return function findMatches(q, cb) {
			var matches, substringRegex;

			matches = [];

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









