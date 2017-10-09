



let initTypeahead = function () {

	var states = ['Alabama', 'Alaska', 'Arizona', 'Arkansas', 'California',
		'Colorado', 'Connecticut', 'Delaware', 'Florida', 'Georgia', 'Hawaii',
		'Idaho', 'Illinois', 'Indiana', 'Iowa', 'Kansas', 'Kentucky', 'Louisiana',
		'Maine', 'Maryland', 'Massachusetts', 'Michigan', 'Minnesota',
		'Mississippi', 'Missouri', 'Montana', 'Nebraska', 'Nevada', 'New Hampshire',
		'New Jersey', 'New Mexico', 'New York', 'North Carolina', 'North Dakota',
		'Ohio', 'Oklahoma', 'Oregon', 'Pennsylvania', 'Rhode Island',
		'South Carolina', 'South Dakota', 'Tennessee', 'Texas', 'Utah', 'Vermont',
		'Virginia', 'Washington', 'West Virginia', 'Wisconsin', 'Wyoming'
	];

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
			name: 'states',
			source: substringMatcher(states)
		}
	});

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
	});
}









