
bwd := justfile_directory()
build_config := env_var_or_default("DOTNET_BUILD_CONFIG", "Debug")


restore:
    dotnet restore {{bwd}}/say.sln

build:
    dotnet build {{bwd}}/say.sln -c {{build_config}} --no-restore 

moo:
    {{bwd}}/BearzSay/src/bin/{{build_config}}/net7.0/bearzsay "moo"