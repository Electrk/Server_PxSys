function PxSysTCP::echo ( %this, %a0, %a1, %a2, %a3, %a4, %a5, %a6, %a7, %a8, %a9, %a10, %a11 )
{
	echo ("\c4[PxSysTCP] \c0" @ %a0 @ %a1 @ %a2 @ %a3 @ %a4 @ %a5 @ %a6 @ %a7 @ %a8 @ %a9 @ %a10 @ %a11);
}

// ------------------------------------------------


function PxSysTCP::connectToServer ( %this )
{
	%this.connect (%this.address @ ":" @ %this.port);
}

function PxSysTCP::onDNSFailed ( %this )
{
	%this.echo ("\c2DNS failed!");
	PxSys_messageAll ("DNS failed!");
}

function PxSysTCP::onConnectFailed ( %this )
{
	%this.echo ("\c2Failed to connect!");
	PxSys_messageAll ("Failed to connect!");
}

function PxSysTCP::onConnected ( %this )
{
	%this.echo ("Connected.");
	PxSys_messageAll ("Connected.");
}

function PxSysTCP::onDisconnect ( %this )
{
	%this.echo ("Disconnected.");
	PxSys_messageAll ("Disconnected.");
}
