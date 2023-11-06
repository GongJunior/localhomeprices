import argparse
from .db import getSchema

def getParser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(prog='Dev Console',description='Console for project')
    parser.add_argument('command', choices=['db', 'api'],help='commands')
    parser.add_argument('--show-schema', dest='schema',action='store_const', const=getSchema, help='show db schema')

    return parser

def process_parcer_old(args, parser):
    kwargs = vars(args)
    provided_args = [t for t in kwargs.items() if t[1]]
    print_only = ['schema']

    if len(provided_args) != 1:
        parser.error("Please select 1 option. -? for help")
    
    arg = provided_args[0]
    if arg[0] in print_only:
        arg[1]()