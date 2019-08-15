// Dummy brick so PxSys prints are always loaded if they're enabled
datablock fxDTSBrickData (brickPxSysDummyData)
{
	brickSizeX = 1;
	brickSizeY = 1;
	brickSizeZ = 1;

	hasPrint = true;
	printAspectRatio = "PxSys";
};

// hrrrnnnggh, colonel...

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
