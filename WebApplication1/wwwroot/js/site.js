// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function handleChange(a, id, email, role) {
	alert(role);
	var roleCheck = "";
	if (a.innerText == "+") {
		a.innerHTML = "-";
		roleCheck = "remove";
	}
	else {
		a.innerHTML = "+";
		roleCheck = "add";
	}

	$.ajax({
		method: "POST",
		url: "/Roles/AddRole",
		data: {
			user_name: email,
			changeRole: role,
			add_remove: roleCheck
		}
	});
};



function changeText(id) {
	id.innerHTML = "ooops";
}