import argparse
from dataclasses import dataclass
from .db import getSchema

@dataclass
class RootNameSpace:
    command: str

@dataclass
class DbNamespace:
    command: str
    show_schema: bool = False

@dataclass
class ApiNamespace:
    command: str
    test_add_address: bool

def getParser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(prog='Dev Console',description='Console for project')
    parser.set_defaults(func=_handle_default_case)
    # parser.add_argument('command', choices=['db', 'api'],help='commands')
    # parser.add_argument('--show-schema', dest='schema',action='store_const', const=getSchema, help='show db schema')

    subparsers = parser.add_subparsers(dest='command')
    parser_db = subparsers.add_parser('db')
    parser_db.add_argument('--show-schema', action='store_true')
    parser_db.set_defaults(func=_handle_db_command)

    parser_api = subparsers.add_parser('api')
    parser_api.add_argument('--test-add-address', action='store_true')
    parser_api.set_defaults(func=_handle_api_command)

    return parser

def _handle_default_case(args: RootNameSpace) -> None:
    print(args)

def _handle_db_command(args: DbNamespace) -> None:
    print(args)

def _handle_api_command(args: ApiNamespace) -> None:
    print(args)

def process_parcer_old(args, parser):
    kwargs = vars(args)
    provided_args = [t for t in kwargs.items() if t[1]]
    print_only = ['schema']

    if len(provided_args) != 1:
        parser.error("Please select 1 option. -? for help")
    
    arg = provided_args[0]
    if arg[0] in print_only:
        arg[1]()