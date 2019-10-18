/**
 * Author:    Kaelin Hoang
 * Partner:   Khanhly Nguyen
 * Date:      10/18/2019
 * Course:    CS 4540, University of Utah, School of Computing
 * Copyright: CS 4540 and Kaelin Hoang and Khanhly Nguyen - This work may not be copied for use in Academic Coursework.
 *
 * We, Kaelin Hoang and Khanhly Nguyen, certify that we wrote this code from scratch and did not copy it in part or whole from
 * another source.  Any references used in the completion of the assignment are cited in my README file.
 *
 * File Contents
 *
 * This is a JavaScript file that handles not submissions for both course notes and learning outcome notes. This JavaScript file
 * calls the corresponding controller in order to compute database queries and logic that will then return to this file to update
 * views.
 */

// This function handles course notes when the submit button is clicked. This function calls the courseInstance controller to add
// or remove notes within the database.
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


// This function handles learning outcome notes when the submit button is clicked. This function calls the learningOutcomes controller 
// to add or remove notes within the database.
function submit_lo_note(e, note_id, lo_id) {
	console.log("in submit_note function");
	console.log(e);
	e.preventDefault();

	$.ajax({
		url: "/LearningOutcomes/ChangeNote",

		data:
		{
			note: $("#loNote").val(),
			note_id: note_id,
			lo_id: lo_id,
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