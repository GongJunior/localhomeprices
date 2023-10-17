# Summary
    Get housing prices in my local area

# Todo
    - Setup database - x
        - Logs to track request
            - hash to group requests by run
            - date
            - page requested
            - success
            - error message
            - type
            - expected total results
            - actual total results
        - housing data
            - request id
            - other details
    - Setup api to interact with app
        - takes post with search type and search value
            - checks request limit
            - requests data from zillow
            - stores data in database
            - check if number of pages will cause request limit to be exceeded
            - if so, return error
            - else, request remaining pages with 1 sec sleep between requests
            - add requests to request log
            - return response
                - number of results loded
                - number of requests made
                - total requests made in last 30 days
            - TODO: Add Swagger and Swashbuckle
        - takes get with property size, num bed, num bath
            - returns aggregation of data
    - Containerize