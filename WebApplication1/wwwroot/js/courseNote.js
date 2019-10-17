$(function ()
{
	console.log("loaded");
});

function submit_note(e)
{
	console.log("in submit_note function");
	console.log(e);
	e.preventDefault();

	$.ajax({
		data: {
			url:"/CourseInstancesController/ChangeNote",
			note: "This is a class note",
			note_id: 1,
		}
	}).done(function (result) {
		console.log("action taken: " + result)
		}).fail(function (jqXHR, textStatus, errorThrown) {
			console.log("failed: ");
			console.log(jqXHR);
			console.log(textStatus);
			console.log(errorThrown);
		}).always(function () {
			console.log("but I will always do this")
		});
}