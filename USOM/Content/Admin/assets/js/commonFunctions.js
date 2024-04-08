
function sendAjaxCall(url, data) {
	return new Promise(function (resolve, reject) {
		$.ajax(url, {
			type: 'POST',  // http method
			data: data,
			success: function (data) {
				resolve(data);
			},
			error: function (data) {
				reject(data);
			}
		})
	});
}

$(document).ready(function () {
	$('.rich-text-area').summernote({
		height: 150,
		codemirror: {
			theme: 'cosmo'
		},
		toolbar: [
			// [groupName, [list of button]]
			['style', ['bold', 'italic', 'underline', 'clear']],
			//['font', ['strikethrough', 'superscript', 'subscript']],
			['fontsize', ['fontsize']],
			//['insert', ['link', 'table']],
			['color', ['color']],
			['para', ['ul', 'ol', 'paragraph']],
			//['height', ['height']],
			//['view', ['fullscreen', 'codeview', 'help']],

		]
	});

	$('#service-form').on('reset', function () {
		$('.rich-text-area').code('');
	});

	//Initialize Select2 Elements
	$('.select2').select2({
		closeOnSelect: true
	})
});
$('#start').on("change", function () {
	var select = $(this)[0].selectedIndex;
	$('option').removeAttr('disabled');  //in case start time is changed
	$.each($('#end option'), function () {
		var disable = $(this).index();
		if (disable < select) {
			$(this).attr('disabled', 'disabled');
		} else {
			$(this).removeAttr('disabled').prop('selected', true);
			return false;
		}
	});
});