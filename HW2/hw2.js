function onlyNum() { 
if(!(event.keyCode==46)&&!(event.keyCode==8)&&!(event.keyCode==37)&&!(event.keyCode==39)) 
if(!((event.keyCode>=48&&event.keyCode<=57)||(event.keyCode>=96&&event.keyCode<=105))) 
event.returnValue=false; 
} 

function addThead() {
    "use strict";
    var tab = $("<table>", {
        "class": "numTable"
    });
    var thead = $("<thead>\
			      <tr>\
			         <th>Times</th>\
					 <th>Result</th>\
			      </tr>\
				</thead>");
    thead.appendTo(tab);
	return tab;
}

function addHighRow(num, time) {
    "use strict";
    var tab = $("<table>", {
        "class": "numTable"
    });

	var tbody = $("<tbody>");
    var trow = $("<tr>");
    var tdat = null;
	tdat = $("<td>").html(time);
	tdat.appendTo(trow);
	tdat = $("<td>").html("The number is higher than " + num);
	tdat.appendTo(trow);
	trow.appendTo(tbody);
    tbody.appendTo(tab);
    return tab;
}

function addLowRow(num, time) {
    "use strict";
    var tab = $("<table>", {
        "class": "numTable"
    });

	var tbody = $("<tbody>");
    var trow = $("<tr>");
    var tdat = null;
	tdat = $("<td>").html(time);
	tdat.appendTo(trow);
	tdat = $("<td>").html("The number is lower than " + num);
	tdat.appendTo(trow);
	trow.appendTo(tbody);
    tbody.appendTo(tab);
    return tab;
}

function addEqualRow(num, time) {
    "use strict";
    var tab = $("<table>", {
        "class": "numTable"
    });

	var tbody = $("<tbody>");
    var trow = $("<tr>");
    var tdat = null;
	tdat = $("<td>").html(time);
	tdat.appendTo(trow);
	tdat = $("<td>").html("Congratulations, you are right!");
	tdat.appendTo(trow);
	trow.appendTo(tbody);
    tbody.appendTo(tab);
    return tab;
}

var randomNumber = parseInt(Math.random() * 100) + 1;
var i = 0;
$("#theTable").append(addThead());
$("#generateTable").submit(function (event) {
    event.preventDefault();
    var num = $("#dateSelect").val().trim();
	if(1 <= num && num <= 100) {
		i++;
		if(num > randomNumber) {
			$("#theTable").append(addLowRow(num, i));
		}
		else if (num < randomNumber) {
			$("#theTable").append(addHighRow(num, i));
		}
		else {
			$("#theTable").append(addEqualRow(num, i));
		}
	}
	else {
		console.log("Date number invalid: " + num);
        $("#dateEntry").html("Please input a number between 1 and 100");
	}
});