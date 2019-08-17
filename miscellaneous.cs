// Dummy brick so PxSys prints are always loaded if they're enabled
datablock fxDTSBrickData (brickPxSysDummyData)
{
	brickSizeX = 1;
	brickSizeY = 1;
	brickSizeZ = 1;

	hasPrint = true;
	printAspectRatio = "PxSys";
};

// hrrrnnnggh, colonel... i'm trying to build around...

// ------------------------------------------------


function PxSys_echo ( %msg0, %msg1, %msg2, %msg3, %msg4, %msg5, %msg6, %msg7 )
{
	echo ("\c4[PxSys] \c0" @ %msg0 @ %msg1 @ %msg2 @ %msg3 @ %msg4 @ %msg5 @ %msg6 @ %msg7);
}

function PxSys_onError ( %command, %errorCode, %errorMessage, %data )
{
	switch$ ( %command )
	{
		case "SV_ERROR":
			PxSys_echo ("\c2Server Error: " @ %errorMessage);

		case "CL_ERROR":
			PxSys_echo ("\c2Client Error: " @ %errorMessage);

		case "CS_ERROR":
			PxSys_echo ("\c2Error: " @ %errorMessage);
	}
}

// ------------------------------------------------


package Server_PxSys
{
	function onMissionLoaded ()
	{
		Parent::onMissionLoaded ();

		%featuresDisabled = false;
		%msg = "WARNING: Server_PxSys - ";

		if ( $printARNumPrintsPxSys > 0 )
		{
			if ( $printNameTable["PxSys/colorPxID_0"] !$= "" )
			{
				$PxSys::ColorPrintsEnabled = true;
			}
			else
			{
				%featuresDisabled = true;
				%msg = %msg @ "PxSys prints enabled, but none following the format `colorPxID_#`\n";
			}
		}
		else
		{
			%featuresDisabled = true;
			%msg = %msg @ "No PxSys prints are enabled on this server!\n";
		}

		if ( $printARNumPrintsLetters $= ""  ||  $printARNumPrintsLetters <= 0 )
		{
			%featuresDisabled = true;			
			%msg = %msg @ "No letter prints are enabled on this server!\n";
		}
		else
		{
			$PxSys::LetterPrintsEnabled = true;
		}

		if ( %featuresDisabled )
		{
			%msg = %msg @ "  +- Certain features of PxSys will be disabled.";
			warn (%msg);
		}
	}

	function onMissionEnded ()
	{
		Parent::onMissionEnded ();

		deleteVariables ("$PxSys::Screen::*");
		$PxSys::HasBrickScreen      = false;
		$PxSys::ColorPrintsEnabled  = false;
		$PxSys::LetterPrintsEnabled = false;
	}
};
activatePackage (Server_PxSys);
