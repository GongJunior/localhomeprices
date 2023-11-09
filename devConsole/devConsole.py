import json

def loadConfig():
    from pathlib import Path
    import utils
    appsettings = Path(__file__).parent / 'appsettings.json'
    with open(appsettings, 'r') as f:
        config = json.load(f)
        utils.config = config

if __name__ == '__main__':
    loadConfig()
    import utils.parseConfigs as pc

    parser = pc.getParser()
    args: pc.CallableNamespace = parser.parse_args()
    args.func(args)
