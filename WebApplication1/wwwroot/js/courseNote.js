$(function ()
{
	console.log("loaded");
});

function submit_note(e, note_id, course_id)
{
	console.log("in submit_note function");
	console.log(e);
	e.preventDefault();

	$.ajax({
		url: "/CourseInstances/ChangeNote",

		data:
		{
			note: $("#note").val(),
			note_id: note_id,
			course_id: course_id,
		},

		method: e.srcElement.method
	}).done(function (result) {
		console.log("action taken: " + result);
	}).fail(function (jqXHR, textStatus, errorThrown) {
		console.log("failed: ");
		console.log(jqXHR);
		console.log(textStatus);
		console.log(errorThrown);
	}).always(function () {
		console.log("but I will always do this")
	});
}