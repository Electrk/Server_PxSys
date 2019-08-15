function PxSysTCP::onLine ( %this, %line )
{
	%cmd = getField (%line, 0);
	%a0  = getField (%line, 1);
	%a1  = getField (%line, 2);
	%a2  = getField (%line, 3);
	%a3  = getField (%line, 4);
	%a4  = getField (%line, 5);
	%a5  = getField (%line, 6);
	%a6  = getField (%line, 7);
	%a7  = getField (%line, 8);
	%a8  = getField (%line, 9);
	%a9  = getField (%line, 10);
	%a10 = getField (%line, 11);
	%a11 = getField (%line, 12);

	switch$ ( %cmd )
	{
		case "SV_SCREEN_SIZE":
			$PxSys::Width  = %a0;
			$PxSys::Height = %a1;

		case "SV_PIXEL_DATA":
			if ( %a2 $= "colorPrintID" )
			{
				$PxSys_[%a0, %a1].setPrint ($printNameTable["PxSys/colorPxID", %a3]);
			}
			else if ( %a2 $= "colorID" )
			{
				$PxSys_[%a0, %a1].setColor (%a3);
			}
			else if ( %a2 $= "printID" )
			{
				$PxSys_[%a0, %a1].setPrint (%a3);
			}
			else if ( %a2 $= "letterPrint" )
			{
				$PxSys_[%a0, %a1].setPrint (letterToPrintID (%a3));
			}
			else if ( %a2 $= "colorFxID" )
			{
				$PxSys_[%a0, %a1].setColorFX (%a3);
			}
			else if ( %a2 $= "shapeFxID" )
			{
				$PxSys_[%a0, %a1].setShapeFX (%a3);
			}

		case "SV_ERROR" or "CL_ERROR" or "CS_ERROR":
			PxSys_onError (%cmd, %a0, %a1, %a2);

		default:
			return;
	}
}

function PxSysTCP::sendCommand ( %this, %cmd, %a0, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11 )
{
	%commandString = %cmd;

	for ( %i = 0;  %i < 12;  %i++ )
	{
		if ( %a[%i] $= "" )
		{
			break;
		}

		%commandString = %commandString TAB %a[%i];
	}

	%this.send (%commandString);
}
