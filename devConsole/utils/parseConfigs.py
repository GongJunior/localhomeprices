import argparse
from . import db
from . import api
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
    parser_db.add_argument('--show-schema', dest='get_schema',action='store_const', const=db.getSchema, help='show db schema')
    parser_db.set_defaults(func=_handle_db_command)

    parser_api = subparsers.add_parser('api')
    parser_api.add_argument('--add-address', dest='test_add_address', action='store_const', const=api.add_addresses, help='send post request to app with sample data')
    parser_api.add_argument('--val-estimate', dest='test_get_estimate', action='store_const', const=api.get_estimates, help='send get request to retrive estimate' )
    parser_api.set_defaults(func=_handle_api_command)

    return parser

def _handle_default_case(args: RootNamespace, parser: argparse.ArgumentParser) -> None:
    parser.print_help()
    # print('Add -h option for usage')

def _handle_db_command(args: DbNamespace, parser: argparse.ArgumentParser) -> None:
    if args.get_schema:
        args.get_schema()
        return

    print('Add -h option for usage')

def _handle_api_command(args: ApiNamespace, parser: argparse.ArgumentParser) -> None:
    if args.test_get_estimate:
        api.get_estimates()
        return
    
    if args.test_add_address:
        api.add_addresses()
        return
    
    print('Add -h option for usage')
    

# show subparser message
# https://stackoverflow.com/questions/20094215/argparse-subparser-monolithic-help-output