{
  description = "Nix Configuration GUI";

  inputs = {
    nixpkgs.url = "github:nixos/nixpkgs";
    flake-utils.url = "github:numtide/flake-utils";
    rnix-lsp.url = "github:nix-community/rnix-lsp";
  };

  outputs = { self, nixpkgs, rnix-lsp, flake-utils }:
  flake-utils.lib.eachDefaultSystem (system:
    let
      pkgs = nixpkgs.legacyPackages.${system};
    in {
      packages.calc = pkgs.callPackage (
        {
          fetchFromGitHub,
          buildDotnetModule,
          copyDesktopItems,
          pkgs
        }:

        buildDotnetModule rec {
          name = "calculator";
          version = "1.0.3";

          src = fetchFromGitHub {
            owner = "TheBunnyMan123";
            repo = name;
            rev = "v${version}";
            sha256 = "sha256-XlDZBOPG0SJjVw+esFNMc9wo6d9VkvBDjo7MmNPn+2Y=";
          };

          runtimeDeps = [ pkgs.fontconfig pkgs.xorg.libX11 pkgs.xorg.libICE pkgs.xorg.libSM ];

          nugetDeps = ./deps-calc.nix;
          projectFile = "Calculator.csproj";

          postInstall = ''
            mkdir -p $out/share/icons
            cp ./Assets/Accessories-calculator.svg $out/share/icons/com.thekillerbunny.calculator.svg
          '';
        }
      );

      apps = {
        calculator = flake-utils.lib.mkApp {
          drv = self.packages."${system}".calc;
        };
      };

      defaultApp = self.apps."${system}".calculator;
    }
  );
}
