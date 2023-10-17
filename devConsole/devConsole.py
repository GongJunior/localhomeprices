import argparse, json

def loadConfig():
    from pathlib import Path
    import utils
    appsettings = Path(__file__).parent / 'appsettings.json'
    with open(appsettings, 'r') as f:
        config = json.load(f)
        utils.config = config

if __name__ == '__main__':
    loadConfig()
    import utils.db as db

    parser = argparse.ArgumentParser(prog='Dev Console',description='Console for project')
    parser.add_argument('--show-schema', dest='schema',action='store_const', const=db.getSchema, help='show db schema')
    parser.add_argument('--hi')
    args = parser.parse_args()
    kwargs = vars(args)
    provided_args = [t for t in kwargs.items() if t[1]]
    print_only = ['schema']

    if len(provided_args) != 1:
        parser.error("Please select 1 option. -? for help")
    
    arg = provided_args[0]
    if arg[0] in print_only:
        arg[1]()
