import argparse
from .db import getSchema
from typing import Any, Callable

class CallableNamespace(argparse.Namespace):
    def __init__(self, **kwargs: Any) -> None:
        super().__init__(**kwargs)
    def func() -> None:
        pass

class RootNamespace(argparse.Namespace):
    def __init__(self, **kwargs: Any) -> None:
        super().__init__(**kwargs)
        self.command: str

class DbNamespace(argparse.Namespace):
    def __init__(self, **kwargs: Any) -> None:
        super().__init__(**kwargs)
        self.command: str
        self.get_schema: Callable

class ApiNamespace(argparse.Namespace):
    def __init__(self, **kwargs: Any) -> None:
        super().__init__(**kwargs)
        self.command: str
        self.test_add_address: Callable
        self.test_get_estimate: Callable

def getParser() -> argparse.ArgumentParser:
    parser = argparse.ArgumentParser(prog='Dev Console',description='Console for project')
    parser.set_defaults(func=_handle_default_case)

    subparsers = parser.add_subparsers(dest='command')
    parser_db = subparsers.add_parser('db')
    parser_db.add_argument('--show-schema', dest='get_schema',action='store_const', const=getSchema, help='show db schema')
    parser_db.set_defaults(func=_handle_db_command)

    parser_api = subparsers.add_parser('api')
    parser_api.add_argument('--test-post-addaddress', action='store_true')
    parser_api.add_argument('--test-get-valestimate', action='store_true')
    parser_api.set_defaults(func=_handle_api_command)

    return parser

def _handle_default_case(args: RootNamespace) -> None:
    vars(args)

def _handle_db_command(args: DbNamespace) -> None:
    if args.get_schema:
        args.get_schema()
        return
    print(vars(args))

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