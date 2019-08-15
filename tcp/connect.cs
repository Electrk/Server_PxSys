function PxSysTCP::echo ( %this, %msg0, %msg1, %msg2, %msg3, %msg4, %msg5, %msg6, %msg7 )
{
	echo ("\c4[PxSysTCP] \c0" @ %msg0 @ %msg1 @ %msg2 @ %msg3 @ %msg4 @ %msg5 @ %msg6 @ %msg7);
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
