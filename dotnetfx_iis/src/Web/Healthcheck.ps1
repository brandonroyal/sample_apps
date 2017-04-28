try {
    $response = Invoke-WebRequest http://localhost/api/health -UseBasicParsing;
    if ($response.StatusCode -eq 200) { 
        return 0
    }
    else {
        return 1
    };
} catch { 
    return 1
}