$PxSys::LetterToPrintID["&"] = "-and";
$PxSys::LetterToPrintID["'"] = "-apostrophe";
$PxSys::LetterToPrintID["\""] = "-apostrophe2";
$PxSys::LetterToPrintID["*"] = "-asterisk";
$PxSys::LetterToPrintID["@"] = "-at";
$PxSys::LetterToPrintID["!"] = "-bang";
$PxSys::LetterToPrintID["^"] = "-caret";
$PxSys::LetterToPrintID[":"] = "-colon";
$PxSys::LetterToPrintID[","] = "-comma";
$PxSys::LetterToPrintID["}"] = "-curlybracketleft";
$PxSys::LetterToPrintID["{"] = "-curlybracketright";
$PxSys::LetterToPrintID["¤"] = "-currencysign";
$PxSys::LetterToPrintID["$"] = "-dollar";
$PxSys::LetterToPrintID["="] = "-equals";
$PxSys::LetterToPrintID["€"] = "-euro";
$PxSys::LetterToPrintID[">"] = "-greater_than";
$PxSys::LetterToPrintID["<"] = "-less_than";
$PxSys::LetterToPrintID["ß"] = "-longs";
$PxSys::LetterToPrintID["-"] = "-minus";
$PxSys::LetterToPrintID["%"] = "-percent";
$PxSys::LetterToPrintID["."] = "-period";
$PxSys::LetterToPrintID["+"] = "-plus";
$PxSys::LetterToPrintID["£"] = "-pound";
$PxSys::LetterToPrintID["#"] = "-poundsymbol";
$PxSys::LetterToPrintID["?"] = "-qmark";
$PxSys::LetterToPrintID[")"] = "-roundbracketleft";
$PxSys::LetterToPrintID["("] = "-roundbracketright";
$PxSys::LetterToPrintID["\\"] = "-slashleft";
$PxSys::LetterToPrintID["/"] = "-slashright";
$PxSys::LetterToPrintID[" "] = "-space";
$PxSys::LetterToPrintID["]"] = "-squarebracketleft";
$PxSys::LetterToPrintID["["] = "-squarebracketright";
$PxSys::LetterToPrintID["~"] = "-tilde";
$PxSys::LetterToPrintID["¨"] = "-umlaut";
$PxSys::LetterToPrintID["_"] = "-underscore";
$PxSys::LetterToPrintID["|"] = "-verticalbar";
$PxSys::LetterToPrintID["0"] = "0";
$PxSys::LetterToPrintID["1"] = "1";
$PxSys::LetterToPrintID["2"] = "2";
$PxSys::LetterToPrintID["3"] = "3";
$PxSys::LetterToPrintID["4"] = "4";
$PxSys::LetterToPrintID["5"] = "5";
$PxSys::LetterToPrintID["6"] = "6";
$PxSys::LetterToPrintID["7"] = "7";
$PxSys::LetterToPrintID["8"] = "8";
$PxSys::LetterToPrintID["9"] = "9";
$PxSys::LetterToPrintID["A"] = "A";
$PxSys::LetterToPrintID["B"] = "B";
$PxSys::LetterToPrintID["C"] = "C";
$PxSys::LetterToPrintID["D"] = "D";
$PxSys::LetterToPrintID["E"] = "E";
$PxSys::LetterToPrintID["F"] = "F";
$PxSys::LetterToPrintID["G"] = "G";
$PxSys::LetterToPrintID["H"] = "H";
$PxSys::LetterToPrintID["I"] = "I";
$PxSys::LetterToPrintID["J"] = "J";
$PxSys::LetterToPrintID["K"] = "K";
$PxSys::LetterToPrintID["L"] = "L";
$PxSys::LetterToPrintID["M"] = "M";
$PxSys::LetterToPrintID["N"] = "N";
$PxSys::LetterToPrintID["O"] = "O";
$PxSys::LetterToPrintID["P"] = "P";
$PxSys::LetterToPrintID["Q"] = "Q";
$PxSys::LetterToPrintID["R"] = "R";
$PxSys::LetterToPrintID["S"] = "S";
$PxSys::LetterToPrintID["T"] = "T";
$PxSys::LetterToPrintID["U"] = "U";
$PxSys::LetterToPrintID["V"] = "V";
$PxSys::LetterToPrintID["W"] = "W";
$PxSys::LetterToPrintID["X"] = "X";
$PxSys::LetterToPrintID["Y"] = "Y";
$PxSys::LetterToPrintID["Z"] = "Z";


function letterToPrintID ( %letterString )
{
	%printLetter = $PxSys::LetterToPrintID[%letterString];

	if ( %printLetter $= ""  ||  %letterString $= " "  ||  %letterString $= "\t" )
	{
		%printLetter = "-space";
	}

	return $printNameTable["Letters/" @ %printLetter];
}

function letterToPrintTexture ( %letterString )
{
	%printLetter = $PxSys::LetterToPrintID[%letterString];

	if ( %printLetter $= ""  ||  %letterString $= " "  ||  %letterString $= "\t" )
	{
		%printLetter = "-space";
	}

	return getPrintTexture ($printNameTable["Letters/" @ %printLetter]);
}
