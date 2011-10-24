# See http://docs.fabfile.org/en/1.0.1/tutorial.html
from __future__ import with_statement
from fabric.api import *
from fabric.contrib.console import prompt,confirm
from lxml import etree

def commit():
  local("git add . && git commit")
  
def prepare_deploy(version):
  commit()
  local("mkdir 'd20 SRD Spell Lists/bin/Release/%s'" % (version))
  local("mv 'd20 SRD Spell Lists/bin/Release/*' 'd20 SRD Spell Lists/bin/Release/%s/'" % (version))
  local("cp AppUpdaterSetup/*.* 'd20 SRD Spell Lists/bin/Release/'")
  doc = etree.parse('d20 SRD Spell Lists/bin/Release/AppStart.config')
  folder = doc.find('AppFolderName')
  folder.text = version
  doc.write('d20 SRD Spell Lists/bin/Release/AppStart.config', True)
  