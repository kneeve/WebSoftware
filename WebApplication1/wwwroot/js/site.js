// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function handleChange(a, id, email, role) {

	// Sweet alert messages
	Swal.fire({
		title: 'Wait!',
		text: 'Do you want to continue',
		type: 'warning',
		showCancelButton: true,
		confirmButtonText: 'Yes',
		cancelButtonText: 'No'
	}).then((result) => {
		if (result.value) {

			var roleCheck = "";
			if (a.innerText == "+") {
				roleCheck = "remove";
			}
			else {
				roleCheck = "add";
			}

			$.ajax({
				method: "POST",
				url: "/Roles/AddRole",
				data: {
					user_name: email,
					changeRole: role,
					add_remove: roleCheck
				},
			}).done(function (result) {
				if (result.statusCode == 200) {
					if (a.innerText == "+") {
						a.innerHTML = "-";
					}
					else {
						a.innerHTML = "+";
					}
				}
				else
				{
					Swal.fire({
						title: 'No!',
						text: "Must have at least one admin",
						type: 'error',
						confirmButtonText: 'OK'
					})
				}
			})
		}
	});
};
