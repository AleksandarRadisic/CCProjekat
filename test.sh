version=$(git tag -l 'v*' --sort=-version:refname | head -n 1)
echo "Latest tag: $version"

if [ -z "$version" ]; then
  version="v1"
else
  version=$(echo $version | cut -c 2- | awk -F '.' '{print "v" $1+1}')
fi
echo "Calculated version: $version"