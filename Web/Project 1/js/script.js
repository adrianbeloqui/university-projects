// Array that contains all the candidates in the poll
var candidates = [];

/** Method that add a new candidate to the poll **/
function addCandidate(){

	// Get value from the user's input
	var candidateName = $("#new_candidate").val();

	// Check if the new candidate is already in the system
	if (checkDuplicates(candidateName)){

		// Ask the user if he/she wants to reset the existing candidate's votes
		var response = confirm("There is a candidate with that name in our system already!" +
								"Do you wish to reset this candidate's votes?");
		if (response == true) {
			// Reset the candidate's votes
		    reset_count(candidateName);
		    // Update the bars of the poll
		    drawStatusBars();
		    // Clean the input box
		    $("#new_candidate").val('');
		}
		return;
	}

	// Check if the new candidate's name contains white spaces
	if (hasWhiteSpace(candidateName)){
		alert('The name of the candidate cannot have white spaces');
		return;
	}

	if (candidates.length == 0) {
		$('.welcome_div').remove();
	}

	// Set the table row for the new candidate
	var imageColumn = '<td class="center"><input id="' + candidateName + '" type="image" value="submit" src="images/vote.png" alt="vote" class="check_image"/></td>';
	var nameColumn = '<td class="candidate_name" id="name_' + candidateName + '">' + candidateName + "</td>";
	var statusColumn = '<td class="status_bar_tr"><div id="status_bar_' + candidateName + '" class="status_bar"></div></td>';
	var votesColumn = '<td class="votes" id="votes_count_' + candidateName +'">0 votes</td>';
	var tableRow = '<tr id="tr_' + candidateName + '">' + imageColumn + nameColumn + statusColumn + votesColumn + "</tr>";
	
	// Add the new candidate's table row to the last position of the table
	$('#pull_candidates > tbody:last-child').append(tableRow);

	// Add the new candidate to the array of candidates
	candidates.push({'name': candidateName,
					   'votes': 0});

	// Find the candidate's button for voting and set click function to add votes
	var voteBtn = $("#" + candidateName);
    voteBtn.click(function (){
    	for (var i = 0; i < candidates.length; ++i) {
    		if (candidates[i].name === candidateName){
    			candidates[i].votes += 1;
    			drawStatusBars();
    		}
		}
    });

    // Update the bars of the poll
    drawStatusBars();
    // Clean the input box
    $("#new_candidate").val('');
	return;
}

/** Method that resets the votes of a candidate to zero **/
function reset_count(candidateName) {
	for (var i = 0; i < candidates.length; ++i) {
    		if (candidates[i].name === candidateName){
    			candidates[i].votes = 0;
    			break;
    		}
		}
}

/** Method that deletes a candidate from the poll **/
function delCandidate(){
	// Get the input of the user
	var candidateName = $("#del_candidate").val();
	var indexToDelete = -1;

	// Find the index of the arrays of candidates where the candidate that is meant to be deleted resides.
	for (var i = 0; i < candidates.length; ++i) {
    		if (candidates[i].name === candidateName){
    			indexToDelete = i;
    			break;
    		}
		}

	// If this candidate exist in the poll, then delete it.
	if (indexToDelete !== -1){
		// Find the table row of the candidate to be deleted and remove it from the HTML
		$('#tr_' + candidateName).remove();
		// Remove the candidate from the array of active candidates
		candidates.splice(indexToDelete, 1);
		// Clean the input box
		var candidateName = $("#del_candidate").val('');
		// Update the bars of the poll
		drawStatusBars();
		// If there are no more active candidates, show the welcome message again
		if (candidates.length === 0){
			create_welcome_div();
		}
    	return;
	}
	// Alert the user that the candidate he entered was not found in the system, therefore, could not be deleted
	alert('We could not find an option with the name ' + candidateName + ' listed in our options.');
}

/** Method that draws the bars for each candidate **/
function drawStatusBars(){
	var totalVotes = 0;
	// Get the total number of votes
	for (var i = 0; i < candidates.length; ++i) {
    		totalVotes += candidates[i].votes;
		}

	// Draw the bar of each candidate depending of the total votes and his/her votes
	for (var i = 0; i < candidates.length; ++i) {
			var num = candidates[i].votes;
			// If total votes is 0, cannot be divided by zero, so is set manually.
			if (totalVotes != 0){
				// Calculate percentage of the bar that will be drawn
				percentage = Math.round((num / totalVotes) * 100) + '%';
			}
			else {
				percentage = '0%';
			}
			// Update the candidate's votes count in the HTML
			var voteCount = $('#votes_count_' + candidates[i].name);
			voteCount.text(candidates[i].votes + ' votes');
			// Draw the bar for the candidate'
			var statusBar = $('#status_bar_' + candidates[i].name)
			statusBar.animate({ 'width': percentage });
			statusBar.text(percentage);
		}
}

/** Method that searches for a candidate in the array of active candidates**/
function checkDuplicates(candidateName){
	// A candidate must have a name in order to be added to the poll
	if (candidateName == ''){
		alert('A name for the candidate must be entered. An empty name is not a valid option.');
		return true;
	}
	// Searh in the array of active candidates if there is a duplicate of a candidate accordingly to the name
	// coming from the paramenter passed
	for (var i = 0; i < candidates.length; ++i) {
    		if (candidates[i].name === candidateName){
    			return true;
    		}
		}
	return false;
}

/** Method that returns true or false if a string contains a white space or not **/
function hasWhiteSpace(str) {
	return str.indexOf(' ') >= 0;
}

/** Method that creates a div with a welcome message in the HTML document **/
function create_welcome_div(){
	$('.pull_panel').append('<h1 class="welcome_div">Create your first candidate...</h1>');
}

/** Method that executes just after the whole site is loaded. Sets clicks method to exiting buttons.**/
function doStart() {
	// Set 'Add' button its corresponding click function
	var addBtn = $("#add_candidate");
    addBtn.click(addCandidate);
    // Set 'Delete' button its corresponding click function
    var delBtn = $("#delete_candidate");
    delBtn.click(delCandidate);
    // Create the welcome message
    create_welcome_div();
}

// Call a function after the whole HTML document is completely loaded
$(document).ready(doStart);