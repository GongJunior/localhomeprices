import utils
import requests

base_url = utils.config['api']['url']['http']

def add_addresses() -> None:
    endpoint = 'addaddresses'
    url = f'{base_url}/{endpoint}'
    json_body = utils.config['api']['samplepayloads']['valid']

    response = requests.post(url=url, json=json_body)
    json_response = response.json()
    print(json_response)


def get_estimates():
    endpoint = 'getestimate'
    params = utils.config['api']['samplepayloads']['getparams'].values()
    url = f'{base_url}/{endpoint}/{'/'.join([str(p) for p in params])}'
    response = requests.get(url=url)
    print(response.json())