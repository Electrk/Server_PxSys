exec ("./createBrick.cs");
exec ("./letterToPrintID.cs");
exec ("./build.cs");

// ------------------------------------------------


function initPxSysScreen ( %appName, %appVersion, %brickGroup )
{
	$PxSys::Screen::AppName    = defaultValue (%appName, $PxSys::Default::AppName);
	$PxSys::Screen::AppVersion = defaultValue (%appVersion, $PxSys::Default::AppVersion);
	$PxSys::Screen::BrickGroup = defaultValue (%brickGroup, $PxSys::Default::BrickGroup);
}

// ------------------------------------------------


function PxSys_setSize ( %width, %height )
{
	$PxSys::Screen::Width  = %width;
	$PxSys::Screen::Height = %height;
}

function PxSys_getPixel ( %x, %y )
{
	return $PxSys_[%x, %y];
}

function PxSys_setPixel ( %x, %y, %object )
{
	$PxSys_[%x, %y] = %object;
}

function PxSys_deleteAllPixels ()
{
	%width  = $PxSys::Screen::Width;
	%height = $PxSys::Screen::Height;

	for ( %x = 0;  %x < %width;  %x++ )
	{
		for ( %y = 0;  %y < %height;  %y++ )
		{
			%pixel = PxSys_getPixel (%x, %y);

			if ( isObject (%pixel) )
			{
				%pixel.delete ();
				$PxSys_[%x, %y] = "";
			}
		}
	}

	$PxSys::HasBrickScreen = false;
}
