rm -rf ./covstats
rm -rf ./TestResults/*

clear
dotnet test --collect:"XPlat COde Coverage;Format=lcov" --settings ./coverlet.runsettings

# Ask to open the coverage report if there wasn't an error
if [ $? -eq 0 ]
then
    echo "Tests passed!"
else
    echo "Tests failed!"
    exit 1
fi

# Save path of first .lcov file

for directory in ./TestResults/*
do
    lcov_path=$directory/coverage.info

    if [ -f $lcov_path ]
    then
        lcov_file=$lcov_path
        break
    fi
done

if [ -z "$lcov_file" ]
then
    echo "Error: .lcov file not found"
    exit 1
fi

# Copy .lcov file to root directory

cp $lcov_file ./lcov.info

# Generate report

reportgenerator -reports:./lcov.info  -targetdir:./covstats

echo "Do you want to open the coverage report? (y/n)"
read answer
if [ "$answer" != "${answer#[Yy]}" ] ;then
    open ./covstats/index.html
fi