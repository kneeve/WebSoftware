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
 * This is a JavaScript file that handles role changes when a role is trying to be added to the table displayed on the web page. It
 * ensures that there will always be at least one administrator, otherwise it will show an error message to the user indicating that
 * their action is denied from removing all administrators. Alerts pop up on the screen whenever a role is being added or removed.
 */

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

            // Indicates to the controller whether to add or remove
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
                // checks the status to see if the role that the user is trying to edit is allowed
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
                    // restricts users from removing all admins ensuring at least one admin at all times
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
